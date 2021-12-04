using UnityEngine;

public class Player : Entity
{
    private RunPlayerState runState;
    private DamagedPlayerState damagedState;
    private DeathPlayerState deathState;
    private Attack1PlayerState attack1State;
    private Attack2PlayerState attack2State;
    private Attack3PlayerState attack3State;
    private FallPlayerState fallState;
    private JumpPlayerState jumpState;
    private LandPlayerState landState;
    private RollPlayerState rollState;

    [SerializeField] private PlayerInputController inputController;
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private PlayerAttackController attackController;
    [SerializeField] private ParticleSystem dustParticles;

    public PlayerInputController InputController => inputController;
    public PlayerMovement Movement => movement;
    public PlayerAttackController AttackController => attackController;
    public ParticleSystem DustParticles => dustParticles;

    private void Start()
    {
        GameManager.instance.Player = this;
    }

    public override IState InitialState(StateMachine stateMachine)
    {
        return runState ??= new RunPlayerState(this, stateMachine);
    }

    public override IState DamagedState(StateMachine stateMachine)
    {
        return damagedState ??= new DamagedPlayerState(this, stateMachine);
    }

    public override IState DeathState(StateMachine stateMachine)
    {
        return deathState ??= new DeathPlayerState(this, stateMachine);
    }

    public Attack1PlayerState Attack1State(StateMachine stateMachine)
    {
        return attack1State ??= new Attack1PlayerState(this, stateMachine);
    }

    public Attack2PlayerState Attack2State(StateMachine stateMachine)
    {
        return attack2State ??= new Attack2PlayerState(this, stateMachine);
    }

    public Attack3PlayerState Attack3State(StateMachine stateMachine)
    {
        return attack3State ??= new Attack3PlayerState(this, stateMachine);
    }

    public FallPlayerState FallPlayerState(StateMachine stateMachine)
    {
        return fallState ??= new FallPlayerState(this, stateMachine);
    }

    public JumpPlayerState JumpState(StateMachine stateMachine)
    {
        return jumpState ??= new JumpPlayerState(this, stateMachine);
    }

    public LandPlayerState LandState(StateMachine stateMachine)
    {
        return landState ??= new LandPlayerState(this, stateMachine);
    }

    public RollPlayerState RollState(StateMachine stateMachine)
    {
        return rollState ??= new RollPlayerState(this, stateMachine);
    }
}
