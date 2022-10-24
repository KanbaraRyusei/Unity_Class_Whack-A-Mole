using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleManager : MonoBehaviour
{
    public IReadOnlyList<MoleController> Moles => _moles;

    private List<MoleController> _moles = new List<MoleController>();

    public void Register(MoleController mole)
    {
        _moles.Add(mole);
    }
}
