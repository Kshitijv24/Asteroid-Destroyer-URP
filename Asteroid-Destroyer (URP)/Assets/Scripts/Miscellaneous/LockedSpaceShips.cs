using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockedSpaceShips : MonoBehaviour
{
	[SerializeField] Image lockedImage;

    private void Start() => HideLockedImage();

    private void ShowLockedImage() => lockedImage.gameObject.SetActive(true);

    private void HideLockedImage() => lockedImage.gameObject.SetActive(false);
}
