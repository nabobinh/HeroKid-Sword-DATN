using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
  public class StateAnimationSetDirectionary : SerializableDictionary<CharacterState, DirectionalAnimationSet>
  {
    public AnimationClip GetFacingClipFromState(CharacterState characterState, Vector2 facingDirection)
    {
        if(TryGetValue(characterState, out DirectionalAnimationSet animationSet)){
            return animationSet.GetFacingClip(facingDirection);
        }else{
            Debug.LogError($"Character state {characterState.name} is not found in the StateAnimations dictionary");
        }
        return null;
    }
  }