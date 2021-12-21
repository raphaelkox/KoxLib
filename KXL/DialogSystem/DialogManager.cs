using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace KXL.DialogSystem
{
    using Core;
    using Core.Enumerations;
    using Data;
    using Data.Events;
    using Enumerations;
    using GameState;
    using GameState.Enumerations;
    using Input;
    using ScriptableObjects;
    using System;
    using System.Linq;
    using UI;

    public static class DialogManager
    {
        static DialogUI DialogUI { get; set; }

        static bool controlFlag;
        static bool playerFlag;
        static bool timeFlag;

        static DSNodeSO currentNode;

        static DSDialogContext currentContext;

        public static void SetupDialogUI(DialogUI dialogUI) {
            Debug.Log("Setup DialogUI");
            DialogUI = dialogUI;

            DialogUI.DialogBox.Hide();
            DialogUI.SpeakerBox.Hide();
            DialogUI.ResponseBox.Hide();

            DialogUI.DialogBox.OnPastLastPage += OnNodeHandleEnd;
        }

        public static void StartDialog(DSNodeSO startNode, bool blockControl, bool freezeTime, bool freezePlayer = true) {
            Debug.Log("START DIALOG");

            controlFlag = blockControl;
            timeFlag = freezeTime;
            playerFlag = freezePlayer;

            if (blockControl) {
                UpdateGroupsManager.SetUpdateGroupState(UpdateGroup.PlayerInput, false);
            }
            if (freezeTime) UpdateGroupsManager.SetUpdateGroupState(UpdateGroup.World, false);
            if (freezePlayer) UpdateGroupsManager.SetUpdateGroupState(UpdateGroup.Player, false);

            HandleNode(startNode);
        }

        static void HandleNode(DSNodeSO node) {
            currentNode = node;

            switch (currentNode.NodeType) {
                case DSNodeType.DialogSingleChoice:
                case DSNodeType.DialogMultipleChoice:
                    if(currentContext != DSDialogContext.DialogBox) {
                        currentContext = DSDialogContext.DialogBox;
                        UpdateGroupsManager.SetUpdateGroupState(UpdateGroup.MenuInput, true);
                        MenuInputGroup.OnConfirmInputDown += DialogUI.DialogBox.NextPage;
                    }

                    DialogUI.ShowDialog((DSDialogNodeSO)currentNode);                    
                    break;
                case DSNodeType.FlagGate:
                    DSNodeOutputData defaultOutput = null;

                    foreach (DSNodeOutputData outputData in currentNode.Outputs) {
                        if(outputData.Text.ToLower() == "default") {
                            defaultOutput = outputData;
                            continue;
                        }

                        FlagName flag = (FlagName)Enum.Parse(typeof(FlagName), outputData.Text);

                        if (Flags.IsFlagSet(flag) && outputData.NextNode != null) {
                            HandleNode(outputData.NextNode);
                            return;
                        }
                    }

                    if(defaultOutput != null && defaultOutput.NextNode != null) {
                        HandleNode(defaultOutput.NextNode);
                        return;
                    }

                    EndDialog();
                    break;
            }

            foreach (DSEventData nodeEvent in node.Events) {
                nodeEvent.Execute();
            }
        }

        public static void OnNodeHandleEnd() {
            if (currentNode.IsLastNode) {
                EndDialog();
                return;
            }

            switch (currentNode.NodeType) {
                case DSNodeType.DialogSingleChoice:
                    HandleNode(currentNode.Outputs[0].NextNode);
                    return;
                case DSNodeType.DialogMultipleChoice:
                    if(currentContext == DSDialogContext.DialogBox) {
                        MenuInputGroup.OnConfirmInputDown -= DialogUI.DialogBox.NextPage;
                    }
                    currentContext = DSDialogContext.ResponseBox;
                    MenuInputGroup.OnConfirmInputDown += SelectResponse;
                    MenuInputGroup.OnUpInputDown += DialogUI.ResponseCursor.PreviousOption;
                    MenuInputGroup.OnDownInputDown += DialogUI.ResponseCursor.NextOption;

                    DialogUI.ShowResponseOptions((DSDialogNodeSO)currentNode);
                    break;
                case DSNodeType.FlagGate:
                    break;
            }
        }

        private static void SelectResponse() {
            MenuInputGroup.OnConfirmInputDown -= SelectResponse;
            MenuInputGroup.OnUpInputDown -= DialogUI.ResponseCursor.PreviousOption;
            MenuInputGroup.OnDownInputDown -= DialogUI.ResponseCursor.NextOption;
            DialogUI.ResponseBox.Hide();

            DSNodeOutputData selectedResponse = currentNode.Outputs[DialogUI.ResponseCursor.currentOption];
            if (selectedResponse.NextNode == null) {
                EndDialog();
                return;
            }
            HandleNode(selectedResponse.NextNode);
        }

        public static void EndDialog() {
            Debug.Log("END DIALOG");
            DialogUI.DialogBox.Hide();

            MenuInputGroup.OnConfirmInputDown -= DialogUI.DialogBox.NextPage;
            UpdateGroupsManager.SetUpdateGroupState(UpdateGroup.MenuInput, false);

            if (controlFlag) {
                UpdateGroupsManager.SetUpdateGroupState(UpdateGroup.PlayerInput, true);
                controlFlag = false;
            }

            if (timeFlag) {
                UpdateGroupsManager.SetUpdateGroupState(UpdateGroup.World, true);
                timeFlag = false;
            }

            if (playerFlag) {
                UpdateGroupsManager.SetUpdateGroupState(UpdateGroup.Player, true);
                playerFlag = false;
            }

            currentContext = DSDialogContext.None;
        }
    }
}