// Setup the board
var ctx = Require<ArduinoContext>();
var board = ctx.CreateBoard();
var led13 = new Led(board, 13);

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
	}	
}

private void TurnOnLed()
{
	led13.On();
}

private void TurnOffLed()
{
	led13.Off();
}

