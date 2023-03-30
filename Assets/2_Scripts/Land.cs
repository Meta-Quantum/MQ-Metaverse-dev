using System;

[Serializable]
public class Land
{
	public enum LandSize
	{
		Small,
		Medium,
		Large
	}
	
	public LandSize landSize;
	public int price;
}
