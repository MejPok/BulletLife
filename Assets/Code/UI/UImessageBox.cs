using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImessageBox : MonoBehaviour
{
    public IGetResponseUI respondTo;

    public void Accepted(bool didIt){
        respondTo.GotAccepted(didIt);
    }
}
