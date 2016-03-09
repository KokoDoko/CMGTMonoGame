//
// een list van game objects
//
private List<GameObject> allGameObjects = new List<GameObject>();

private void CreateObjects(){
	_gameobjects.Add(new Rock());
	_gameobjects.Add(new Ship());
} 


//
// een functie die check of de icollidables elkaar raken
//
private void CheckCollisions(){

	List<ICollidable> onlyCollidables = new List<ICollidable>(_gameobjects.OfType<ICollidable>());

	foreach(ICollidable object1 in onlyCollidables)
	{
		foreach(ICollidable object2 in onlyCollidables)
		{
			if(object1 != object2 && HitBoxesIntersect(object1, object2))
			{
				// er is een collision tussen object1 en object2 !
			}
		}
	}
		
}

//
// een functie die elementen uit list kan verwijderen
//
private void RemoveDeadObjects(){
	for(var i = allGameObjects.Count; i>0; i--){
		if(allGameObjects[i] is IRemovable){
			IRemovable obj = (IRemovable)allGameObjects[i];
			allGameObjects.Remove(obj);
		}
	}

}