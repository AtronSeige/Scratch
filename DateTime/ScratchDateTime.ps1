# Get the date and format it 
$date = Get-Date -Format "yyyy/MM/dd HH:mm"
Write-Host "Date Time : [$date]"

# Add 5 minutes to the date
# $date = (Get-Date).AddMinutes(5).ToString("HH:mm")
$date = (Get-Date).AddMinutes(5).ToString("yyyy/MM/dd HH:mm")
Write-Host "New Time : [$date]"


$date = (Get-Date).AddSeconds(300).ToString("yyyy/MM/dd HH:mm")
Write-Host "New Time : [$date]"

