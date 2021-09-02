using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarVisual : MonoBehaviour
{
    [SerializeField] private Sprite heartSprite;
    [SerializeField] private Sprite damagedHeartSprite;
    [SerializeField] private AnimationClip heartExpandAnimationClip;

    private float sizeDelta = 48;
    private List<HeartImage> heartImageList;
    private HealthBarSystem healthBarSystem;

    public HealthBarSystem HealthBarSystem => healthBarSystem;

    private void Awake()
    {
        heartImageList = new List<HeartImage>();
    }

    private void Start()
    {
        HealthBarSystem healthBarSystem = new HealthBarSystem(GameManager.instance.Player);
        SetHealthBarSystem(healthBarSystem);
    }

    public void SetHealthBarSystem(HealthBarSystem healthBarSystem)
    {
        this.healthBarSystem = healthBarSystem;

        List<HealthBarSystem.Heart> heartList = healthBarSystem.HeartList;
        Vector2 offset = Vector2.zero;
        for (int i = 0; i < heartList.Count; i++)
        {
            HealthBarSystem.Heart heart = heartList[i];
            CreateHeartImage(offset).Index = heart.Index;
            offset += new Vector2(sizeDelta, 0);
        }

        healthBarSystem.OnHealthChanged += RefreshAllHearts;
    }

    private HeartImage CreateHeartImage(Vector2 offset)
    {
        GameObject heartGameObject = new GameObject("Heart", typeof(Image), typeof(Animation));

        heartGameObject.transform.SetParent(transform, false);
        heartGameObject.transform.localPosition = Vector3.zero;

        RectTransform rectTransform = heartGameObject.GetComponent<RectTransform>();
        rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, offset.y, sizeDelta);
        rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, offset.x, sizeDelta);

        Animation animation = heartGameObject.GetComponent<Animation>();
        animation.AddClip(heartExpandAnimationClip, "Expand");
        Image heartImageUI = heartGameObject.GetComponent<Image>();
        heartImageUI.sprite = heartSprite;

        HeartImage heartImage = new HeartImage(this, heartImageUI, animation);
        heartImageList.Add(heartImage);

        return heartImage;
    }

    private void RefreshAllHearts()
    {
        List<HealthBarSystem.Heart> heartList = healthBarSystem.HeartList;

        for (int i = 0; i < heartImageList.Count; i++)
        {
            HeartImage heartImage = heartImageList[i];
            HealthBarSystem.Heart heart = heartList[i];

            int currentIndex = heartImage.Index;
            heartImage.Index = heart.Index;
            
            if (heart.Index == HealthBarSystem.MAX_INDEX && currentIndex != heartImage.Index)
            {
                heartImageList[i].PlayHeartExpandAnimation();
            }
        }
    }

    public class HeartImage
    {
        private int index;
        private HealthBarVisual healthBarVisual;
        private Image heartImage;
        private Animation animation;

        public int Index
        {
            get { return index; }
            set { SetHeartIndex(value); }
        }

        public HeartImage(HealthBarVisual healthBarVisual, Image heartImage, Animation animation)
        {
            this.healthBarVisual = healthBarVisual;
            this.heartImage = heartImage;
            this.animation = animation;
        }

        private void SetHeartIndex(int index)
        {
            this.index = index;

            switch (index)
            {
                case 0: heartImage.sprite = healthBarVisual.damagedHeartSprite; break;
                case 1: heartImage.sprite = healthBarVisual.heartSprite; break;
            }
        }

        public void PlayHeartExpandAnimation()
        {
            animation.Play("Expand", PlayMode.StopAll);
        }
    }
}
