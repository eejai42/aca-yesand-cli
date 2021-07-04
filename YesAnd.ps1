function MainMenu() {
    LoadGlobals;
    if ($global:show -ne $null) {

        Write-Host "`n`nSHOW: " $global:show.Name ""
        Write-Host("1. Change Show");
        Write-Host "2. Start Next Episode"        
        Write-Host "3. Open Episode"
        if ($global:episode -ne $null) {
            Write-Host "`n`nEPISODE: " $global:episode.Name ""
            Write-Host "4. Start Call"
            Write-Host "5. Open Call"
            Write-Host "6. Manage Hosts"
            if ($global:call -ne $null) {
                Write-Host "`n`nCALL: " $global:call.Name ""
                Write-Host "7. Navigate Call"
                Write-Host "8. Manage Participants"
            }
        }
        $option = Read-Host("`nWhat do you want to do?")
    } else {
        Write-Host("`n`n1. Pick Show");
        $option = "1"
    }
    if ($option -eq "1") {
        $global:show = ChooseShow
        MainMenu
    } elseif ($option -eq "2") {
        $global:episode = StartNextEpisode $global:show
        MainMenu
    } elseif ($option -eq "3") {
        $global:episode = OpenEpisode $global:show
        MainMenu
    } elseif ($option -eq "4") {
        $global:call = StartCall $global:episode
        MainMenu
    } elseif ($option -eq "5") {
        $global:call = OpenCall $global:episode        
        MainMenu
    } elseif ($option -eq "6") {
        $global:hosts = ManageHosts $global:episode
        MainMenu
    } elseif ($option -eq "7") {
        NavigateCall $global:call
        MainMenu
    } elseif ($option -eq "8") {
        DoNothing
        MainMenu
    }
}


function NavigateCall($call) {
    Write-Host "`n`nNavigating call"
    LoadTopics $call
    LoadParticipants $call

    $result = ""
    while ($result -ne "x") {
        PrintCallMenu $call
        $result = Read-Host("Navigate forward")
        if ($result[0] -eq "1") {
            SetSpeaker $call 1
        }
        elseif ($result[0] -eq "2") {
            SetSpeaker $call 2
        }
        elseif ($result[0] -eq "3") {
            SetSpeaker $call 3
        }
        elseif ($result[0] -eq "4") {
            SetAgreement $call 1
        }
        elseif ($result[0] -eq "5") {
            SetAgreement $call 2
        }
        elseif ($result[0] -eq "6") {
            SetAgreement $call 3
        }
        elseif ($result[0] -eq "p") {
            SelectParentTopic $call
        }
        elseif ($result[0] -eq "s" -and $result.length -lt 4) {
            SelectSubTopic $call $result.Substring(1, $result.length - 1)
        }
        elseif ($result.length -gt 1) {
            AddSubTopic $call $result
        }
    }
}

function LoadTopics($call) {
    $reply = yesand GetCallTopics -where "$('"')EpisodeCall='$($call.Name)'$('"')" -view TopicList | ConvertFrom-Json
    if (HasNoErrors($reply)) {
        $topics = [System.Collections.ArrayList]$reply.CallTopics;
        if ($topics.length -lt 1) {
            $topic = AddTopic $call $null $call.Subject
            $topics.Add($topic)
        }
        $topics | format-table | Out-Host
        $global:topics = $topics
    }
    $global:currentTopic = $global:topics | where ParentTopic -eq $null | select -first 1
}

function LoadParticipants($call) {
    $reply = yesand GetCallParticipants -where "$('"')EpisodeCall='$($call.Name)'$('"')" -view ParticipantList | ConvertFrom-Json
    $reply|convertto-json|out-host
    if (HasNoErrors($reply)) {
        $participants = [System.Collections.ArrayList]$reply.CallParticipants;
        $participants | format-table | Out-Host
        $global:participants = $participants
    }
    $global:currentSpeaker = $global:participants | select -first 1    
}

function SelectParentTopic($call) {
    Write-Host "`n`nSelecting Parent Topic...."
    $subTopics = $global:topics|where CallTopicId -eq $global:currentTopic.ParentTopic;
    $subTopicIndex = [int]$callId
    $selected = $subTopics[$subTopicIndex - 1]
    if ($selected -ne $null) {
        $global:currentTopic = $selected
    }
}

function SelectSubTopic($call, $callId) {
    Write-Host "`n`nSelecting Sub Topic...." $callId $global:currentTopic.CallTopicId
    $subTopics = $global:topics|where ParentTopic -eq $global:currentTopic.CallTopicId;
    $subTopics|format-table|Out-Host
    $subTopicIndex = [int]$callId
    $selected = $subTopics[$subTopicIndex - 1]
    if ($selected -ne $null) {
        $global:currentTopic = $selected
    }
}

function AddSubTopic($call, $subject) {
    $payload = @{
        CallTopic = @{
            EpisodeCall = $call.EpisodeCallId;
            ParentTopic = $global:currentTopic.CallTopicId;
            Subject = $subject;
        }
    }
    $payload|convertto-json|out-file ./payload.json
    $reply = yesand AddCallTopic -bodyfile ./payload.json|convertfrom-json
    if (HasNoErrors($reply)) {
        $global:topics.Add($reply.CallTopic)
    }
}

function AddTopic($call, $parentTopic, $subject) {
    $parentTopicId = $null
    if ($parentTopic -ne $null) {
        $parentTopicId = $parentTopic.CallTopicId
    }

    $payload = @{
        CallTopic = @{
            ParentTopic = $parentTopicId;
            Subject = $subject;
            EpisodeCall = $call.EpisodeCallId;
        } 
    }
    $payload|convertto-json|out-file ./payload.json
    $reply = yesand AddCallTopic -bodyfile ./payload.json
    if (HasNoErrors($reply)) {
        Write-Host "ADDING TOPIC NOW"
    }
}

function PrintCallMenu($call) {    
    $parent = $global:topics|where CallTopicId -eq $global:currentTopic.ParentTopic|select -first 1;
    Write-Host "`n`n`nParent Topic: " $parent.Subject
    Write-Host "   - Current-Topic" $global:currentTopic.Subject
    $subTopics = $global:topics|where ParentTopic -eq $global:currentTopic.CallTopicId;
    foreach ($topic in $subTopics) {
        Write-Host "         - Sub Item: " $topic.Subject
    }

    Write-Host "`nCurrent Speaker:" $global:currentSpeaker.Name

    Write-Host "`n`n"
    Write-Host " 1,2,3 - Set Speaker"
    Write-Host " 4,5,6 - Change Speaker Agreement"


    if ($parent -ne $null) {
        Write-Host " p: SELECT PARENT TOPIC"
    }
    Write-Host " a: ADD SUB TOPIC"
    Write-Host " s3: SELECT SUB TOPIC"
    Write-Host " x: CLOSE CALL NAVIGATATOR"
}

function SetSpeaker($call, $index) {
    $global:currentSpeaker = $global:participants[$index -1];
    Write-Host "`n`n -- CHANGING SPEAKER  $($index) -- `n`n"
    $global:currentSpeaker|convertto-json|Out-Host
    
}

function SetAgreement($call, $index) {
    Write-Host "`n`n -- CHANGING AGREEMENT $($index) -- `n`n"
}

function OpenEpisode($show) {
    $where = "$('"')ShowSeason='$($show.CurrentSeasonName)'$('"')"
    $reply = yesand GetSeasonEpisodes -where $where -view EpisodeList|ConvertFrom-Json
    if (HasNoErrors($reply)) {
        $reply.SeasonEpisodes|select Name|format-table|Out-Host
        $eStr = Read-Host "Which episode?"
        $episodeNumber = [int]$eStr
        $episode = $reply.SeasonEpisodes[$episodeNumber - 1];
        return $episode;
    }
}

function StartNextEpisode($show) {
    $payload = @{
        SeasonEpisode = @{
            ShowSeason = $show.CurrentSeason;
            EpisodeNumber = $show.NextEpisodeNumber;
        }
    }
    $payload|convertto-json|Out-file ./payload.json
    $reply = yesand AddSeasonEpisode -bodyfile ./payload.json|ConvertFrom-Json
    if (HasNoErrors($reply)) {
        $episode = $reply.SeasonEpisode
        AddEpisodeHost $episode "Host"
        AddEpisodeHost $episode "Co-Host"
        return $episode    
    }
}

function AddEpisodeHost($episode, $role) {
    Write-Host "$($episode.Name) $($role)s:" 
    $count = 1;
    foreach ($globalHost in $Global:hosts) {
        Write-host "$($count++). " $globalHost.Name
    }
    $hostString = Read-Host("`n`nWho is the $($role) for $($episode.Name)?")    
    $hostInt = [int]$hostString;
    $person = $global:hosts[$hostInt - 1]
    $episodeHost = CreateEpisodeHost $episode $person $role
    return $episodeHost;
}


function CreateEpisodeHost($episode, $person, $role) {
    $payload = @{
        EpisodeHost = @{
            SeasonEpisode = $episode.SeasonEpisodeId
            Person = $person.PersonId;
            Role = $role;
        }
    }

    $payload | convertto-json | out-file ./payload.json

    $responseJson = yesand AddEpisodeHost -bodyfile ./payload.json
    $response = $responseJson|convertfrom-json

    if (HasNoErrors($response)) {
        return $response.CallParticipant
    }
}

function ChooseShow() {
    $reply = yesand getshows|convertfrom-json;
    if (HasNoErrors($reply)) {
        $reply.Shows|select Name|format-table|Out-Host;
    }
    $showString = Read-Host "Which show would you like to start?";
    $showInt = [int]$showString;
    $show = $reply.Shows[$showInt - 1]
    $global:episode = $null;
    $global:call = $null;
    return $show
}

function DoNothing() {
    Write-Host "DOING NOTHING"
}

function OpenCall($episode) {
    $reply = yesand GetEpisodeCalls -where "$('"')SeasonEpisode='$($episode.Name)'$('"')" -view CallList|ConvertFrom-Json
    if (HasNoErrors($reply)) {
        $calls = $reply.EpisodeCalls
        $calls|select Name,Subject|Format-table|Out-Host
        $callNumber = Read-Host("What call do you want to open?")
        $callNumberInt = [int]$callNumber;
        return $reply.EpisodeCalls[$callNumberInt - 1]
    }
}

function StartCall($episode) {
    $subject = Read-Host("Call Subject?")
    $call = CreateCall $episode  $subject
    AddHost $call "Host";
    AddHost $call "Co-Host";
    AddGuest $call
    return $call
}

function AddHost($call, $role) {
    Write-Host "TEST: " $role
    foreach ($globalHost in $Global:hosts) {
        Write-host $globalHost.Name
    }
    $hostString = Read-Host("Who is the $($role)?")    
    $hostInt = [int]$hostString;
    $person = $global:hosts[$hostInt - 1]
    $participant = AddParticipant $call $null $person
    return $participant;
}

function AddGuest($call) {
    $guestName = Read-Host "Who is the Guest?";
    return AddParticipant $call $guestName $null;
}

function AddParticipant($call, $participantName, $person) {
    $personId = $null;
    if ($person -ne $null) {
        $personId = $person.PersonId;
    }

    $payload = @{
        CallParticipant = @{
            EpisodeCall = $call.EpisodeCallId;
            ChosenName = $participantName;
            Person = $personId;
        }
    }

    $payload | convertto-json | out-file ./payload.json

    $responseJson = yesand AddCallParticipant -bodyfile ./payload.json
    $response = $responseJson|convertfrom-json

    if (HasNoErrors($response)) {
        return $response.CallParticipant
    }
}

function CreateCall($episode, $callSubject) {
    $payload = @{
        EpisodeCall=@{
            SeasonEpisode=$episode.SeasonEpisodeId;
            Subject=$callSubject;
        }
    }

    $payload|convertto-json|out-file ./payload.json
    $response = yesand AddEpisodeCall -bodyfile ./payload.json|convertfrom-json

    if (HasNoErrors($response)) {
        Write-Host("GOT CALL")
        write-host($response|convertto-json)
        return $response.EpisodeCall
    }
}

function HasNoErrors($payload) {
    if ($payload.ErrorMessage -ne $null) {
        Write-Host($payload.ErrorMessage)
        return $false
    } else {
        return $true
    }
}

function LoadGlobals() {
    $payload = yesand GetPeople -where "Roles='Host'"|convertfrom-json
    if (HasNoErrors($payload)) {
        $global:hosts = $payload.People
    }
}

# $global:show = $null
# $global:episode = $null
# $global:call = $null

MainMenu