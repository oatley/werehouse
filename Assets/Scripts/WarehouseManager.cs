using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarehouseManager : MonoBehaviour {
	private Animator anim;
	[SerializeField] private Texture[] tex_windows;
	[SerializeField] private SkinnedMeshRenderer smr_windows;
	private Material mat_windows;

	[SerializeField] private GameObject go_ghost;
	[SerializeField] private GameObject go_ghostSpawnLocator;

	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator>();
		anim.SetLayerWeight(1,0);
		mat_windows = smr_windows.material;
	}
	
	// Update is called once per frame
	void Update () {
		/* if(Input.GetKeyDown(KeyCode.Q))
			SetStage(0);
		if(Input.GetKeyDown(KeyCode.W))
			SetStage(1);
		if(Input.GetKeyDown(KeyCode.E))
			SetStage(2);
		if(Input.GetKeyDown(KeyCode.R))
			SetStage(3);
		if(Input.GetKeyDown(KeyCode.T))
			SetStage(4);
		if(Input.GetKeyDown(KeyCode.Y))
			SpawnGhost();*/
	}

	public void SetStage(int i_stage){
		if(i_stage > 4) i_stage = 4;
		if(i_stage < 0) i_stage = 0;

		float f_weight = 0;
		if(i_stage > 0)
			f_weight = 1-((float) 1.0f/ (float) i_stage);
		anim.SetLayerWeight(1,f_weight);

		mat_windows.mainTexture = tex_windows[i_stage];
	}

	public void SpawnGhost()
	{
		Instantiate(go_ghost,go_ghostSpawnLocator.transform.position,Quaternion.identity);
	}
}
