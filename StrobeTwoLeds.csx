// Setup the board
var ctx = Require<ArduinoContext>();
var board = ctx.CreateBoard();
var led2 = new Led(board, 3);

// setup the delay
Action wait = () => Thread.Sleep(2.Seconds());

Console.WriteLine("Begin");

// Strobe one led
led2.StrobeOn();
wait();
led2.StrobeOff();

// Strobe two leds
var led13 = new Led(board, 11);
led13.StrobeOn();
wait();
led2.StrobeOn();
wait();
led2.StrobeOff();
wait();
led13.StrobeOff();
led13.Off();
led2.Off();

Console.WriteLine("End");
