using Microsoft.Xna.Framework;

namespace capybara;

public class AnimationManager
{

	int numFrames;
	int numColumns;
	Vector2 size;

	int counter;
	int activeFrame;
	int interval;

	int rowPos;
	int colPos;

	public AnimationManager(int numFrames, int numColumns, Vector2 size, int interval)
	{
		this.numFrames = numFrames;
		this.numColumns = numColumns;
		this.size = size;

		this.interval = interval;
		counter = 0;
		activeFrame = 0;

		rowPos = 0;
		colPos = 0;
	}

	public void Update()
	{
		counter++;
		if(counter > interval)
		{
			counter = 0;
			NextFrame();
		}
	}

	public void NextFrame()
	{
		activeFrame++;
		colPos++;

		if(activeFrame >= numFrames)
		{
			ResetAnimation();
		}

		if(numColumns > 1 && colPos >= numColumns)
		{
				colPos = 0;
		}
	}

	public void ResetAnimation()
	{
		activeFrame = 0;
		colPos = 0;
		rowPos = 0;
	}

	public Rectangle GetFrame()
	{
		return new Rectangle(
				colPos * (int)size.X,
				rowPos * (int)size.Y,
				(int)size.X,
				(int)size.Y);
	}
}
