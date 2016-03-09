private List<GameObject> vehicles = new List<GameObject>();

public World()
{
	vehicles.Add(new Car());
	vehicles.Add(new Truck());

}

public void Update()
{
	foreach(GameObject go in vehicles) {
		go.Update();
		go.Draw();
	}
}

public void Draw()
{
	foreach(GameObject go in vehicles) {
		go.Update();
		go.Draw();
	}
}