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
    $reply = yesand GetCallTopics -where "$('"')EpisodeCall='$($call.Name)'$('"')" -view TopicList|ConvertFrom-Json
    if (HasNoErrors($reply)) {
        $topics = $reply.CallTopics;
        $topics|Out-Host
        if ($topics.length -lt 1) {
            $topic = AddTopic $call $null $call.Subject
            $topics.Add($topic)
        }
        $topics|format-table|Out-Host        
        $global:topics = [System.Collections.ArrayList]$topics
        $global:currentTopic = $global:topics|where ParentTopic -eq $null|select -first 1

        
        $global:currentTopic|convertto-json|Out-Host

        $result = ""
        while ($result -ne "x") {
            PrintCallMenu $call
            $result = Read-Host("Navigate forward")
            if ($result[0] -eq "p") {
                SelectParentTopic $call
            } elseif ($result[0] -eq "a") {
                AddSubTopic $call $result.Substring(1, $result.length - 1)
            } elseif ($result[0] -eq "s") {
                SelectSubTopic $call $result.Substring(1, $result.length - 1)
            }
        }
    }
}

function SelectParentTopic($call) {
    Write-Host "`n`nSelecting Parent Topic...."
    $subTopics = $global:topics|where CallTopicId -eq $global:currentTopic.ParentTopic;
    $subTopics|format-table|Out-Host
    $subTopicIndex = [int]$callId
    $selected = $subTopics[$subTopicIndex - 1]
    if ($selected -ne $null) {
        $global:currentTopic = $selected
    }
}

function SelectSubTopic($call, $callId) {
    Write-Host "`n`nSelecting Sub Topic...." $callId
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
        $reply|convertto-json|out-host
        # $global:currentTopic = $reply.CallTopic;
    }

    $global:topics|format-table|out-host
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
    $cur = $global:currentTopic;
    Write-Host "SELECTING CURRENT ITEM: "
    $cur|convertto-json|Out-Host
    $parent = $global:topics|where CallTopicId -eq $cur.ParentTopic|select -first 1;
    Write-Host "`n`n`nParent Topic: " $parent.Subject
    Write-Host "   - Current-Topic" $cur.Subject
    $subTopics = $global:topics|where ParentTopic -eq $cur.CallTopicId;
    foreach ($topic in $subTopics) {
        Write-Host "         - Sub Item: " $topic.Subject
    }

    if ($parent -ne $null) {
        Write-Host "`n`n p: SELECT PARENT TOPIC"
    }
    Write-Host " a: ADD SUB TOPIC"
    Write-Host " s3: SELECT SUB TOPIC"
    Write-Host " x: CLOSE CALL NAVIGATATOR"
}

function OpenEpisode($show) {
    $where = "$('"')ShowSeason='$($show.CurrentSeasonName)'$('"')"
    $where|Out-host
    $reply = yesand GetSeasonEpisodes -where $where|ConvertFrom-Json
    $reply|Out-Host
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
    $episode = $reply.SeasonEpisode
    $episode|Out-Host
    return $episode    
}

function ChooseShow() {
    $reply = yesand getshows|convertfrom-json;
    if (HasNoErrors($reply)) {
        $reply.Shows|select Name|format-table|Out-Host;
    }
    $showString = Read-Host "Which show would you like to start?";
    $showInt = [int]$showString;
    $show = $reply.Shows[$showInt - 1]
    $show|convertto-json|Out-Host
    $global:episode = $null;
    $global:call = $null;
    return $show
}

function DoNothing() {
    Write-Host "DOING NOTHING"
}

function OpenCall($episode) {
    $episode|Out-Host
    $reply = yesand GetEpisodeCalls -where "$('"')SeasonEpisode='$($episode.Name)'$('"')" -view CallList|ConvertFrom-Json
    $reply|Out-host
    if (HasNoErrors($reply)) {
        $calls = $reply.EpisodeCalls
        $calls|select Name,Subject|Format-table|Out-Host
        $callNumber = Read-Host("What call do you want to open?")
        $callNumberInt = [int]$callNumber;
        return $reply.EpisodeCalls[$callNumberInt - 1]
    } else {
        Write-Host $reply.ErrorMessage
    }
}

function StartCall($episode) {
    $subject = Read-Host("Call Subject?")
    $call = CreateCall $episode  $subject
    Write-Host("Details")
    $call|convertto-json
    AddHost $call "Host";
    AddHost $call "Co-Host";
    AddGuest $call
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

    $payload|Out-Host

    $payload | convertto-json | out-file ./payload.json

    $responseJson = yesand AddCallParticipant -bodyfile ./payload.json
    $responseJson|Out-Host
    $response = $responseJson|convertfrom-json

    if (HasNoErrors($response)) {
        return $respo;nse.CallParticipant
    } else {
        return $null;
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
    } else {
        return $null
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