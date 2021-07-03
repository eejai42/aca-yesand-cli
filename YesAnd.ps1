function MainMenu() {
    LoadGlobals;
    Write-Host("1. Pick Show");
    if ($global:show -ne $null) {

        Write-Host "SHOW: " $global:show.Name ""
        Write-Host "2. Start Next Episode"        
        Write-Host "3. Open Episode"
        if ($global:episode -ne $null) {
            Write-Host "EPISODE: " $global:episode.Name ""
            Write-Host "4. Start Call"
            Write-Host "5. Open Call"
            Write-Host "6. Manage Hosts"
            if ($global:call -ne $null) {
                Write-Host "CALL: " $global:call.Name ""
                Write-Host "7. Navigate Call"
                Write-Host "8. Manage Participants"
            }
        }
        $option = Read-Host("What do you want to do?")
    } else {
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
        $global:call = ManageHosts $global:episode
        MainMenu
    } elseif ($option -eq "7") {
        $global:call = NaviateCall $global:call
        MainMenu
    } elseif ($option -eq "8") {
        DoNothing
        MainMenu
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
    return $show
}

function DoNothing() {
    Write-Host "DOING NOTHING"
}

function OpenCall() {
    $reply = yesand GetEpisodeCalls -view "RecentCalls"|ConvertFrom-Json
    if (HasNoErrors($reply)) {
        $calls = $reply|select -expand EpisodeCalls
        $calls|Format-table|Out-Host
        $callNumber = Read-Host("What call do you want to open?")
        $callNumberInt = [int]$callNumber;
        return $reply.EpisodeCalls[$callNumberInt - 1]
    } else {
        Write-Host $reply.ErrorMessage
    }
}

function StartCall($show) {
    $subject = Read-Host("Call Subject?")
    $call = CreateCall($subject)
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

function CreateCall($callSubject) {
    $payload = @{
        EpisodeCall=@{
            Subject=$callSubject
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

$global:show = $null
$global:episode = $null
$global:call = $null

MainMenu