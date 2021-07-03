function MainMenu() {
    LoadGlobals;
    Write-Host("1. Open Call")
    Write-Host("2. Start Call")
    $option = Read-Host("What do you want to do?")
    if ($option -eq "1") {
        $call = OpenCall
        $call|convertto-json
    } elseif ($option -eq "2") {
        StartCall
    }
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

function StartCall() {
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

MainMenu