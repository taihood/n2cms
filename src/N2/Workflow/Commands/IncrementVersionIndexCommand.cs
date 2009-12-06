﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using N2.Persistence;

namespace N2.Workflow.Commands
{
    public class IncrementVersionIndexCommand : CommandBase<CommandContext>
    {
        IVersionManager versionProvider;

        public IncrementVersionIndexCommand(IVersionManager versionProvider)
        {
            this.versionProvider = versionProvider;
        }

        public override void Process(CommandContext state)
        {
            var masterVersion = state.Data.VersionOf ?? state.Data;
            var greatestIndex = versionProvider.GetVersionsOf(masterVersion).Max(v => v.VersionIndex);
            state.Data.VersionIndex = greatestIndex + 1;
        }
    }
}
