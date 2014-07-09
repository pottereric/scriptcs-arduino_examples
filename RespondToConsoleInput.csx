// Setup the board
var ctx = Require<ArduinoContext>();
var board = ctx.CreateBoard();
var led12 = new Led(board, 12);
Console.WriteLine("Begin");
while(true)
{
	var input = Console.ReadLine();
	switch(input.ToLower())
	{	
		case "illuminate":
			TurnOnLed();
			break;
		case "delluminate":
			TurnOffLed();
			break;
		default:
			Console.WriteLine("Unrecognized Command");
			break;
	}	
}

private void TurnOnLed()
{
	led12.On();
}

private void TurnOffLed()
{
	led12.Off();
}

