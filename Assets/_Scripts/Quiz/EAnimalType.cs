using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Flags]
public enum EAnimalType
{
    Flying = 1 << 0,
    Insect = 1 << 1,
    Omnivorous = 1 << 2,
    LivesInGroup = 1 << 3,
    LaysEggs = 1 << 4,
    NonFlying = 1 << 5,
    NonInsect = 1 << 6,
    Herbivorous = 1 << 7,
    LivesSolo = 1 << 8,
    GivesBirth = 1 << 9
}

//-Flying or Non-Flying
//- Insect or Non-Insect
//- Omnivorous or Herbivorous
//- Lives in Group or Solo
//- Lays Eggs or Give Birth
