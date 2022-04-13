using UnityEngine.UI;
using UnityEngine;

namespace Geekbrains
{
    public class DisplayBonuses : MonoBehaviour
    {
        private Text _text;
        public void Start()
        {
            _text = Object.FindObjectOfType<Text>();
        }
        
        public void Display(int value)
        {
            _text.text = $"Вы набрали {value}";
        }
    }
}
