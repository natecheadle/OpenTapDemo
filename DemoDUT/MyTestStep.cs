using OpenTap;

namespace Demo;

[Display("MyTestStep", Description: "Insert a description here", Group: "DemoDUT")]
public class MyTestStep : TestStep
{
    #region Settings
    // ToDo: Add property here for each parameter the end user should be able to change
    public MyDUT? DUT { get; set; }
    #endregion
    public MyTestStep() { }

    public override void PrePlanRun()
    {
        base.PrePlanRun();
        // ToDo: Optionally add any setup code this step needs to run before the testplan starts
    }

    public override void Run()
    {
        // ToDo: Add test case code here
        RunChildSteps(); //If step has child steps.
        UpgradeVerdict(
            DUT is not null && DUT.SerialNumber is not null && DUT.SerialNumber.Length > 0
                ? Verdict.Pass
                : Verdict.Fail
        );

        Log.Info($"MyDUT SerialNumber = {DUT?.SerialNumber}");
    }

    public override void PostPlanRun()
    {
        // ToDo: Optionally add any cleanup code this step needs to run after the entire testplan has finished
        base.PostPlanRun();
    }
}
