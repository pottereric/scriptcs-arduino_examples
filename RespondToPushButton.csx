// Setup the board
var ctx = Require<ArduinoContext>();
var board = ctx.CreateBoard();

var ledPin = 9;
var led2 = new Led(board, ledPin);

var buttonPin = 2;
board.PinMode(buttonPin, PinMode.Input);

// setup the delay
Action wait = () => Thread.Sleep(500);

while(true)
{
	var buttonState = board.DigitalRead(buttonPin);
	if(buttonState == 1)
	{
		Console.WriteLine("On");
		led2.On();
	}
	else
	{
		Console.WriteLine("Off");
		led2.Off();
	}
	
	wait();
}
