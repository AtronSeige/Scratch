TestTryParse();

void TestTryParse()
{
	string validGuid = "b72d02f4-76f9-43e5-80f7-d05ffbd332df";
	string invalidGuid = "this-is-not-a-guid";
	Guid parsedGuid;
	Guid? nullableGuid;

	if (Guid.TryParse(validGuid, out parsedGuid))
	{
		Console.WriteLine($"Successfully parsed GUID: {parsedGuid}");
	}
	else
	{
		Console.WriteLine("Failed to parse valid GUID.");
	}
	
	if (Guid.TryParse(invalidGuid, out parsedGuid))
	{
		Console.WriteLine("Incorrectly parsed an invalid GUID.");
	}
	else
	{
		Console.WriteLine("Correctly identified invalid GUID.");
	}

	if (Guid.TryParse(null, out parsedGuid)) {
		Console.WriteLine("Incorrectly parsed an null GUID.");
	} else {
		Console.WriteLine("Correctly identified null GUID.");
	}

	nullableGuid = Guid.TryParse(validGuid, out Guid temp) ? temp : (Guid?)null;

	if (nullableGuid.HasValue)
	{
		Console.WriteLine($"Successfully parsed GUID: {nullableGuid}");
	}
	else
	{
		Console.WriteLine("Failed to parse valid GUID.");
	}
}