var ctx = Require<ArduinoContext>();
var arduino = ctx.CreateBoard();

var mosfetPin = 12;
var ledPin = 10;

Action wait = () => Thread.Sleep(1.Seconds());

var led = new Led(arduino, ledPin);

arduino.PinMode(mosfetPin, PinMode.Output);

Console.WriteLine("Begin");
while(true)
{
	var input = Console.ReadLine();
	switch(input.ToLower())
	{	
		case "on":
			TurnOnMosfet();
			break;
		case "off":
			TurnOffMosfet();
			break;
		case "fire":
			Fire();
			break;
		default:
			Console.WriteLine("Unrecognized Command");
			break;
	}	
}

private void Fire()
{
	Console.WriteLine("bang");
	TurnOnMosfet();
	wait();
	TurnOffMosfet();
	Console.WriteLine("boom");
}

private void TurnOnMosfet()
{
	arduino.DigitalWrite(mosfetPin, DigitalPin.High);
	led.On();
}

private void TurnOffMosfet()
{
	arduino.DigitalWrite(mosfetPin, DigitalPin.Low);
	led.Off();
}

