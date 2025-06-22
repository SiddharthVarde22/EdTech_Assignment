using UnityEngine;

[CreateAssetMenu(fileName = "Animal Data SO", menuName = "Quiz/AnimalData")]
public class AnimalDataSO : ScriptableObject
{
    [SerializeField] string m_name;
    [SerializeField] EAnimalType m_animalTypes;
    [SerializeField, TextArea(3,10)] string m_description;
    [SerializeField] Sprite m_sprite;

    public EAnimalType GetAnimalTypes()
    {
        return m_animalTypes;
    }
    public string GetAnimalDesription()
    {
        return m_description;
    }
    public string GetAnimalName()
    {
        return m_name;
    }
    public Sprite GetSprite()
    {
        return m_sprite;
    }
}
