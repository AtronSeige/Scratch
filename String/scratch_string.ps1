# List of clients that are special
$specials = @('Country Road', 'Country Road Group', 'Country Road Group Basket Remedial', 'Country Road UAT',
	'David Jones', 'David Jones GNP', 'David Jones Migration', 'David Jones UAT', 'David Jones UAT AUTH FLOW',
	'WHL Group'
)

$clientPath = (Get-Location).Path;

ForEach ($special in $specials) {
	if ($clientPath.Contains($special)) {
		Write-Host ("$clientPath contains $special");
	}
 else {
		Write-Host ("Nothing");
	}
}