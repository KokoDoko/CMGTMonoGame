public class Timer
{
	private float _duration;
	private float _elapsed = 0;

	public Timer(float d)
	{
		_duration = d;
	}

	public bool CheckTime(GameTime gameTime) {
		_elapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
		if(_elapsed > _duration) {
			_elapsed = 0;
			return true;
		}
		return false;
	}
}
