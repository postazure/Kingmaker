using UnityEngine;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour
{

	public int columns = 10;
	public int rows = 10;


	public GameObject[] floorTiles;

	private Transform boardHolder;
	private List<Vector2> gridPositions = new List<Vector2> ();

	void InitializeList ()
	{
		gridPositions.Clear ();

		for (int x = 0; x < columns; x++) {
			for (int y = 0; y < rows; y++) {
				gridPositions.Add (new Vector2 (x, y));
			}
		}
	}

	public void SetupScene()
	{
		BoardSetup ();
		InitializeList ();
//		LayoutObjectAtRandom (wallTiles, wallCount.minimum, wallCount.maximum);
//		LayoutObjectAtRandom (foodTiles, foodCount.minimum, foodCount.maximum);
	}

	void BoardSetup ()
	{
		boardHolder = new GameObject ("Board").transform;
		for (int x = -1; x < columns + 1; x++) {
			for (int y = -1; y < rows + 1; y++) {
				GameObject toInstantiate = floorTiles [Random.Range (0, floorTiles.Length)];
				GameObject instance = Instantiate (toInstantiate, new Vector2 (x, y), Quaternion.identity) as GameObject;
				instance.transform.SetParent (boardHolder);		
			}
		}
	}

	Vector2 RandomPosition(){
		int randomIndex = Random.Range (0, gridPositions.Count);
		Vector2 randomPosition = gridPositions [randomIndex];
		gridPositions.RemoveAt (randomIndex);
		return randomPosition;
	}

	void LayoutObjectAtRandom(GameObject[] tileArray, int minimum, int maximum){
		int objectCount = Random.Range (minimum, maximum + 1);
		for (int i = 0; i < objectCount; i++) {
			Vector2 randomPosition = RandomPosition ();
			GameObject tileChoice = tileArray [Random.Range (0, tileArray.Length)];
			Instantiate (tileChoice, randomPosition, Quaternion.identity);
		}
	}

	void LayoutObjectAtRandom(GameObject[] tileArray, int count){
		LayoutObjectAtRandom (tileArray, count, count);
	}
}
