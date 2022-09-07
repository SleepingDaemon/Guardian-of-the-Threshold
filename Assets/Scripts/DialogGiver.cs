using UnityEngine;

public class DialogGiver : MonoBehaviour
{
    [SerializeField] private TextAsset _dialog;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<TopDownMover>() != null)
        {
            var dialog = FindObjectOfType<DialogController>();
            dialog.StartDialog(_dialog);
        }
    }
}

//public class AlertGiver : MonoBehaviour
//{
//    [SerializeField] private string _alertMessage;

//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.GetComponent<TopDownMover>() != null)
//        {
//            var dialog = FindObjectOfType<DialogController>();
//            dialog.StartDialog(_alertMessage);
//        }
//    }
//}
