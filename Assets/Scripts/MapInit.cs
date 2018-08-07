using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapInit : MonoBehaviour {

	[Header("Map Size")]
	public float seed = 0.0f;
	public float temp_scale = 2.0F;
	public float scale = 1.0F;
	public int width = 20;
	public int height = 20;

	[Header("Temperatures")]
	public float high_temp = 1.0F;
	public float mid_temp = 0.7F;
	public float low_temp = 0.3F;

	[Header("Elevations")]
	public float peak_elevation = 1.0F;
	public float mountain_elevation = 0.9F;
	public float hill_elevation = 0.75F;
	public float land_elevation = 0.6F;
	public float beach_elevation = 0.45F;
	public float sea_elevation = 0.3F;
	public float deep_sea_elevation = 0.15F;

	[Header("Colors")]
	public Color snow_color = new Color(1.0f,1.0f,1.0f,1f);
	public Color cliff_color = new Color(1.0f,1.0f,1.0f,1f);
	public Color mountain_color = new Color(0.6f,0.6f,0.6f,1f);

	public Color desert_color = new Color(0.8f,0.7f,0.0f,1f);
	public Color hill_color = new Color(0.3f,0.9f,0.2f,1f);

	public Color forest_color = new Color(0.1f,0.9f,0.2f,1f);
	public Color meadow_color = new Color(0.3f,0.9f,0.2f,1f);

	public Color beach_color = new Color(0.8f,0.7f,0.0f,1f);
	public Color swamp_color = new Color(0.1f,0.6f,0.5f,1f);

	public Color canyon_color = new Color(0.5f,0.4f,0.3f,1f);
	public Color ice_color = new Color(0.6f,0.6f,0.7f,1f);
	public Color sea_color = new Color(0.0f,0.2f,0.6f,1f);
	public Color deep_sea_color = new Color(0.0f,0.1f,0.4f,1f);

	// Use this for initialization
	void Start () {

		if(seed == 0.0f)
		{
			seed = Random.value * 1000;
		}


		for(int i= 0; i < width; i++)
		{
			for(int j= 0; j < height; j++)
			{
				string name = "Cell[" + i + "][" + j + "]";
				float xCoord = (float)i/width;
				float yCoord = (float)j/height;

				// Debug.Log("x=" + xCoord + ", y=" + yCoord);
				float elevation = Mathf.PerlinNoise(seed + (xCoord * scale), seed + (yCoord * scale));
				// Debug.Log("sample "+ name +"=" + elevation);
				float temp = Mathf.PerlinNoise( (seed+4) + (xCoord*temp_scale), (seed+4) + (yCoord*temp_scale));

				Color col = new Color(0.1f,0.1f,0.1f,1f);

				if(elevation >= mountain_elevation) {
					col = cliff_color;
					if(temp < low_temp) {
						col = snow_color;
					}
				}
				if(elevation < mountain_elevation) {
					col = mountain_color;
				}
				if(elevation < hill_elevation) {
					col = desert_color;
					if(temp < mid_temp) {
						col = hill_color;
					}
				}
				if(elevation < land_elevation) {

					col = desert_color;
					if(temp < mid_temp) {
						col = meadow_color;
					}
					if(temp < low_temp){
						col = forest_color;
					}
				}
				if(elevation < beach_elevation)
				{
					col = beach_color;
					if(temp < low_temp) {
						col = swamp_color;
					}
				}
				if(elevation < sea_elevation) {
					col = canyon_color;
					if(temp < mid_temp) {
						col = sea_color;
					}
					if(temp < low_temp){
						col = ice_color;
					}
				}
				if(elevation < deep_sea_elevation) {
					col = sea_color;
					if(temp < mid_temp) {
						col = deep_sea_color;
					}
				}

				// Color col = new Color(0.6f,0.8f,0.0f,1f);
				// Color col = new Color(sample,sample,sample,1f);

				GameObject newCell = Instantiate(Resources.Load("WorldCell")) as GameObject;
	        	newCell.name = name;
				newCell.transform.position = new Vector3(i,j,0);
				newCell.transform.parent = this.transform;
				newCell.GetComponent<SpriteRenderer>().color = col;
				Debug.Log("made" + name);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
