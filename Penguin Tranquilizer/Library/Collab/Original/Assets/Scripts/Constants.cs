using UnityEngine;
using System.Collections;

public class Constants {
  // Scenes
  public const string SceneBattle = "Battle";
  public const string SceneMenu = "MainMenu";

  // Gun Types
	public const string Sniper = "Sniper";

  // Pickup Types
  public const int PickUpHealth = 4;
  public const int PickUpArmor = 5;
	public const int PickUpSniperAmmo = 6;

  // Misc
  public const string Game = "Game";
  public const float CameraDefaultZoom = 60f;

	public static readonly int[] AllPickupTypes = new int[3] {
	  PickUpHealth,
	  PickUpArmor,
		PickUpSniperAmmo,
	};

}
