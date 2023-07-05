using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
	[SerializeField]
	private	GameObject	imageDialogs;                   // 대화창 Image UI

	[SerializeField]
	private PlayerController playerController;


    public void Setup()
    {

        SetNextDialog();
	}

	bool isEnd = false;

	public void isEndMotion(){
		isEnd = true;
        playerController.MoveState = true;

        imageDialogs.SetActive(false);
        Debug.Log("넘어가유");
	}

	public bool UpdateDialog()
	{
		if ( isEnd == true )
		{
            //Debug.Log("넘어가유");
            //SetNextDialog();
            ///Debug.Log("이제 움직여줘");
            // 대사가 더 이상 없을 경우
            return true;
        }
        
        return false;
	}

    private void SetNextDialog()
	{
		playerController.MoveState = false;

        // 대화창 활성화
        imageDialogs.SetActive(true);
    }

	private void InActiveObjects(int index)
	{
        imageDialogs.SetActive(false);
    }
}

