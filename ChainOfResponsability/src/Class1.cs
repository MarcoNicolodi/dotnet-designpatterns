using System;
using System.Collections.Generic;

namespace ChainOfResponsability
{
public class WebformsComponentCodeBehind
{
    public List<TrainingEffectiveness> TrainingEffectiveness { get; private set; }
    public List<TrainingEvaluations> TrainingEvaluations { get; private set; }

    protected string GetClass(string code, bool approve)
    {
        // Don't bother these
        var evaluation = TrainingEvaluations.Find(x => x.EmployeeCode == code.Split('_')[0] && x.CriteriaCode == code.Split('_')[1]);
        var isNew = code.Split('_')[1] == IEntity.NewCode;
        var effectiveness = TrainingEffectiveness.Find(x => x.EmployeeCode == code.Split('_')[0]);

        // We'll refactor this:
        if (evaluation != null)
        {
            return evaluation.HasEvaluation
                ? approve
                    ? evaluation.IsApproved
                        ? "approvedOn"
                        : "approvedOff"
                    : !evaluation.IsApproved
                        ? "reprovedOn"
                        : "reprovedOff"
                : approve
                    ? "approvedOff"
                    : "reprovedOff";
        }

        if (isNew) return approve ? "approvedOff" : "reprovedOff";

        if (effectiveness == null) return approve ? "approvedOff" : "reprovedOff";

        switch (effectiveness.IsEffective)
        {
            case 0:
                return approve ? "approvedOff" : "reprovedOn";
            case 1:
                return approve ? "approvedOn" : "reprovedOff";
            default:
                return approve ? "approvedOff" : "reprovedOff";
        }
    }
}

public class TrainingEvaluations
{
    public string EmployeeCode { get; internal set; }
    public string CriteriaCode { get; internal set; }
    public bool IsApproved { get; internal set; }
    public bool HasEvaluation { get; internal set; }
}

public class TrainingEffectiveness
{
    public string EmployeeCode { get; internal set; }
    public int IsEffective { get; internal set; }
}

public class IEntity
{
    public const string NewCode = "-2";
}

}
