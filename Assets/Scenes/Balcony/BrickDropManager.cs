using System;
using Items.InteractionDetector;
using Items.Inventory;
using Model;
using UnityEngine;

namespace Scenes.Balcony
{
    public class BrickDropManager : MonoBehaviour
    {
        private IInteractionDetector interactionDetector;
        private bool animationStarted;

        private string brick = "Brick";
        
        private void Start()
        {
            interactionDetector = GetComponent<IInteractionDetector>();
            interactionDetector.Interacted += DropBricks;
        }

        private void Update()
        {
            if (animationStarted)
                Debug.Log("Dropping animation started");
            
            //TODO доделать эту парашу
        }

        private void DropBricks(GameObject obj)
        {
            var inventory = obj.GetComponent<Inventory>();
            if (inventory.Contains(brick, 2) 
                && Core.BalconyState.MullerAppeared)
            {
                inventory.Items.RemoveAll(item => item.Name == brick);
                animationStarted = true;
            }
        }
        
    }
}