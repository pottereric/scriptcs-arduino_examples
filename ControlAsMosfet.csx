var ctx = Require<ArduinoContext>();
var arduino = ctx.CreateBoard();

var mosfetPin = 12;
var ledPin = 10;

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
		default:
			Console.WriteLine("Unrecognized Command");
			break;
	}	
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

