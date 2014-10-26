// Setup the board
var ctx = Require<ArduinoContext>();
var board = ctx.CreateBoard();
var led2 = new Led(board, 3);

// setup the delay
Action wait = () => Thread.Sleep(2.Seconds());

Console.WriteLine("Begin");

StrobeLed(2);
StrobeLed(3);
StrobeLed(4);
StrobeLed(5);
StrobeLed(6);
//StrobeLed(7);
//StrobeLed(8);
StrobeLed(9);
StrobeLed(10);
StrobeLed(11);
StrobeLed(12);
StrobeLed(13);


//wait();
//led2.StrobeOff();
//wait();
//led13.StrobeOff();
//led13.Off();
//led2.Off();

Console.WriteLine("End");

private void StrobeLed(int pin)
{
	Console.WriteLine("pin: {0}", pin);
	var led = new Led(board, pin);
	led.StrobeOn();
	wait();
	led.StrobeOff();
	led.Off();
}
