using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanoidAnimationController : MonoBehaviour
{
    string TALKING_1 = "Talking ${humanoid} 1";
    string TALKING_2 = "Talking ${humanoid} 2";
    string IDLE_1 = "Idle ${humanoid} 1";
    string IDLE_2 = "Idle ${humanoid} 2";
    string IDLE_HAPPY = "Idle Happy";
    string IDLE_LOOKING_AT_HAND = "Idle Looking at Hand";
    string IDLE_SAD = "Idle Sad";
    string IDLE_TOO_HOT = "Idle Too Hot";

    [SerializeField] private Animator _animator;
    [SerializeField] private bool isMale;
    [SerializeField] private bool isFemale;
    [SerializeField] private bool _playTalkingAnimations;

    private bool _isSexSetted = false;

    private List<string> _talkingAnimations = new List<string>();
    private List<string> _idleAnimations = new List<string>();

    private void Awake() {
        if (isMale) {
            TALKING_1 = TALKING_1.Replace("${humanoid}", "Male");
            TALKING_2 = TALKING_2.Replace("${humanoid}", "Male");
            IDLE_1 = IDLE_1.Replace("${humanoid}", "Male");
            IDLE_2 = IDLE_2.Replace("${humanoid}", "Male");
            _isSexSetted = true;
        } else if (isFemale) {
            TALKING_1 = TALKING_1.Replace("${humanoid}", "Female");
            TALKING_2 = TALKING_2.Replace("${humanoid}", "Female");
            IDLE_1 = IDLE_1.Replace("${humanoid}", "Female");
            IDLE_2 = IDLE_2.Replace("${humanoid}", "Female");
            _isSexSetted = true;
        } else {
            Debug.LogError("Sex is not setted, check the HumanoidAnimationController booleans");
        }

        _talkingAnimations.Add(TALKING_1);
        _talkingAnimations.Add(TALKING_2);
        _talkingAnimations.Add(IDLE_1);
        _talkingAnimations.Add(IDLE_2);
        
        _idleAnimations.Add(IDLE_1);
        _idleAnimations.Add(IDLE_2);
        _idleAnimations.Add(IDLE_HAPPY);
        _idleAnimations.Add(IDLE_LOOKING_AT_HAND);
        _idleAnimations.Add(IDLE_SAD);
        _idleAnimations.Add(IDLE_TOO_HOT);
    }
    
    private void Update() {
        if (!_isSexSetted) return;

        var animState = _animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
        if (animState < 1) return;

        if (_playTalkingAnimations) {
            int animIndex = Random.Range(0, _talkingAnimations.Count);
            _animator.Play(_talkingAnimations[animIndex]);
        } else {
            int animIndex = Random.Range(0, _idleAnimations.Count);
            _animator.Play(_idleAnimations[animIndex]);
        }
    }
}
