using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticThings{
	public static bool GameIsPaused = false;
	public static float offsetZ;
	public static float deaths = 0;
	public static int goreValue = 0;
	public static bool isFullScreenToggleOn = true;
	public static float volume = 0;
	public static int resolutionIndex = 0;
	public static int startArmCount = 2;
	public static int levelMenuLevel = 1;
	public static int currentLevel = 1;
	public static int maxLevel = 1;
	public static bool justSpawned = false;
	public static bool firstTimePlayingLevel = true;
	public static bool backgroundGreen = false;
	public static bool foregroundGreen = false;
}
