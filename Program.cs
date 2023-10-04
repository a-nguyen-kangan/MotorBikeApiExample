

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<MotorBike> garage = new List<MotorBike>();

MotorBike m1 = new MotorBike();
m1.Rego = "ABC-123";
m1.Colour = "Green";
m1.EngineCapacity = 1000;

MotorBike m2 = new MotorBike();
m2.Rego = "ZXC-987";
m2.Colour = "Red";
m2.EngineCapacity = 500;

// Faz create an new motorbike m3
MotorBike m3 = new MotorBike();
m3.Rego = "XYZ-456";
m3.Colour = "Orange";
m3.EngineCapacity = 1500;

garage.Add(m1);
garage.Add(m2); 
garage.Add(m3);

app.MapGet("/", () => "Hello MotorBikes!");
app.MapGet("/view-motorbike", () => ViewMotorBike());
app.MapGet("/view-garage", () => ViewGarage());
app.MapGet("/view-motorbike/{rego}", (string rego) => ViewByRego(rego));
//foreach (var motorBike in garage)?
MotorBike ViewByRego(string rego) {
    foreach(MotorBike currentBike in garage) {
        if(currentBike.Rego == rego) {
            return currentBike;
        }
    }

    return null;
}

List<MotorBike> ViewGarage()
{
    return garage; 
}

MotorBike ViewMotorBike() {
    MotorBike m1 = new MotorBike();
    m1.Rego = "ABC-123";
    m1.Colour = "Green";
    m1.EngineCapacity = 1000;

    return m1;
}

app.Run();
