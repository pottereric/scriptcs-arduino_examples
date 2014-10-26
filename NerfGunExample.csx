var ctx = Require<ArduinoContext>();
var arduino = ctx.CreateBoard();

var motorMosfetPin = 10;
var relayMosfetPin = 3;
var ledPin = 11;

Action wait = () => Thread.Sleep(1.Seconds());
Action waitShort = () => Thread.Sleep(75);

var led = new Led(arduino, ledPin);

arduino.PinMode(motorMosfetPin, PinMode.Output);
//arduino.PinMode(motorMosfetPin, PinMode.Analog);
arduino.PinMode(relayMosfetPin, PinMode.Output);

Console.WriteLine("Begin");
while(true)
{
	var input = Console.ReadLine();
	switch(input.ToLower())
	{	
		case "relayon":
			TurnOnRelayMosfet();
			break;
		case "relayoff":
			TurnOffRelayMosfet();
			break;
		case "motoron":
			TurnOnMotorMosfet();
			break;
		case "motoroff":
			TurnOffMotorMosfet();
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
	waitShort();
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
	waitShort();
	TurnOffMotorMosfet();
}

private void TurnOnMotorMosfet()
{
	arduino.DigitalWrite(motorMosfetPin, DigitalPin.High);
	//arduino.AnalogWrite(motorMosfetPin, 200);
	led.On();
}

private void TurnOffMotorMosfet()
{
	arduino.DigitalWrite(motorMosfetPin, DigitalPin.Low);
	//arduino.AnalogWrite(motorMosfetPin, 0);
	led.Off();
}

