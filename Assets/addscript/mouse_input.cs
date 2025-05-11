using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_input : MonoBehaviour
{
    public float sensitivity = 1.0f;
    public float rayDistance = 2f; // Ray�̋���
    public Transform marker; // ���W���������߂̃}�[�J�[�i��F�󒆂�Cube�Ȃǁj
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;  // sensitivity�͉�]���x
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;
        float input_W = Input.GetAxis("Vertical");
        float input_AD = Input.GetAxis("Horizontal");
        Transform cameraTransform = transform.Find("Camera_pos");
        Transform forwardTransform = transform.Find("unitychan");
        Debug.Log(input_AD);
        
        Vector3 NowCamRotation = cameraTransform.rotation.eulerAngles;

        if (NowCamRotation.x >= 50f && NowCamRotation.x < 100f)
        {
            if (-mouseY < 0)
            {
                cameraTransform.rotation = Quaternion.Euler(NowCamRotation.x + -mouseY, NowCamRotation.y, 0);
            }
            else
            {
                cameraTransform.rotation = Quaternion.Euler(NowCamRotation.x, NowCamRotation.y + mouseX, 0);
            }
        }
        else if (NowCamRotation.x <= 300f && NowCamRotation.x > 200f)
        {
            if (-mouseY > 0)
            {
                cameraTransform.rotation = Quaternion.Euler(NowCamRotation.x + -mouseY, NowCamRotation.y, 0);
            }
            else
            {
                cameraTransform.rotation = Quaternion.Euler(NowCamRotation.x, NowCamRotation.y + mouseX, 0);
            }
        }
        else
        {
            cameraTransform.rotation = Quaternion.Euler(NowCamRotation.x + -mouseY, NowCamRotation.y + mouseX, 0);
            cameraTransform.Rotate(-mouseY, mouseX, 0);
        }


        float angleInRadians = Mathf.Atan2(input_W, input_AD);
        float angleInDegrees = angleInRadians * Mathf.Rad2Deg;


        if (input_W != 0 || input_AD != 0)
        {
            angleInDegrees -= 90;
            angleInDegrees *= -1;
            //�J������rotation+Degrees�����Ȃ��Ⴂ���Ȃ�
            Vector3 cameraRotation = cameraTransform.rotation.eulerAngles;
            Vector3 targetRotation = forwardTransform.rotation.eulerAngles;
            targetRotation.y = cameraRotation.y + angleInDegrees;
            forwardTransform.rotation = Quaternion.Euler(targetRotation);
        }
        float input_left = Input.GetAxis("Mouse0");
        if (input_left > 0)
        {
            Debug.Log("�E�N��");
            Vector3 cameraRotation = cameraTransform.rotation.eulerAngles;
            Vector3 targetRotation = forwardTransform.rotation.eulerAngles;
            targetRotation.x = targetRotation.x;
            targetRotation.y = cameraRotation.y + 45;
            targetRotation.z = targetRotation.z;
            //Vector3(0,0,5.63693428)
            //Vector3(356.195618,0.889436722,1.99977243)
            forwardTransform.rotation = Quaternion.Euler(targetRotation);
        }



            // �J�����̒�������Ray���o��
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        // �i�s������rayDistance�̋����ō��W���v�Z
        Vector3 pointInAir = ray.GetPoint(rayDistance);

        // �}�[�J�[�̈ʒu���󒆂̍��W�ɐݒ�
        if (marker != null)
        {
            marker.position = pointInAir;
        }







        
    }
}
