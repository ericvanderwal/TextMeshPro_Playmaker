// (c) Eric Vander Wal, 2017 All rights reserved.
// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using TMPro;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("TextMesh Pro UGUI Basic")]
    [Tooltip("Set Text Mesh Pro UGUI font size.")]
    public class setTextmeshProUGUIFontSize : FsmStateAction
    {
        [RequiredField]
        [CheckForComponent(typeof(TextMeshProUGUI))]
        [Tooltip("Textmesh Pro component is required.")]
        public FsmOwnerDefault gameObject;

        [RequiredField]
        [TitleAttribute("Font Size")]
        [Tooltip("The font size for Textmesh Pro text.")]
        public FsmFloat fontSize;

        [Tooltip("Check this box to preform this action every frame.")]
        public FsmBool everyFrame;

        TextMeshProUGUI meshproScript;

        public override void Reset()
        {
            gameObject = null;
            fontSize = null;
            everyFrame = false;
        }

        public override void OnEnter()
        {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            meshproScript = go.GetComponent<TextMeshProUGUI>();

            DoMeshChange();


            if (!everyFrame.Value)
            {
                Finish();
            }
        }

        public override void OnUpdate()
        {
            if (everyFrame.Value)
            {
                DoMeshChange();
            }
        }

        void DoMeshChange()
        {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            if (go == null)
            {
                return;
            }

            if (meshproScript == null)
            {
                Debug.LogError("No textmesh pro ugui component was found on " + go);
                return;
            }

            meshproScript.fontSize = fontSize.Value;
        }
    }
}