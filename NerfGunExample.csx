var ctx = Require<ArduinoContext>();
var arduino = ctx.CreateBoard();

var motorMosfetPin = 8;
var relayMosfetPin = 12;
var ledPin = 10;

Action wait = () => Thread.Sleep(1.Seconds());

var led = new Led(arduino, ledPin);

arduino.PinMode(motorMosfetPin, PinMode.Output);
arduino.PinMode(relayMosfetPin, PinMode.Output);

Console.WriteLine("Begin");
while(true)
{
	var input = Console.ReadLine();
	switch(input.ToLower())
	{	
		case "on":
			TurnOnRelayMosfet();
			break;
		case "off":
			TurnOffRelayMosfet();
			break;
		case "fire":
			Fire();
			break;
		case "spin":
			Spin();
			break;
		default:
			Console.WriteLine("Unrecognized Command");
			break;
	}	
}

private void Fire()
{
	Console.WriteLine("bang");
	TurnOnRelayMosfet();
	wait();
	TurnOffRelayMosfet();
	Console.WriteLine("boom");
}

private void TurnOnRelayMosfet()
{
	arduino.DigitalWrite(relayMosfetPin, DigitalPin.High);
	led.On();
}

private void TurnOffRelayMosfet()
{
	arduino.DigitalWrite(relayMosfetPin, DigitalPin.Low);
	led.Off();
}

private void Spin()
{
	TurnOnMotorMosfet();
	wait();
	TurnOffMotorMosfet();
}

private void TurnOnMotorMosfet()
{
	arduino.DigitalWrite(motorMosfetPin, DigitalPin.High);
	led.On();
}

private void TurnOffMotorMosfet()
{
	arduino.DigitalWrite(motorMosfetPin, DigitalPin.Low);
	led.Off();
}

