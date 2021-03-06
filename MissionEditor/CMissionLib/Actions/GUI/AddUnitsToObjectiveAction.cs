﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CMissionLib.Actions
{
	/// <summary>
	/// Specifies a unit group whose members the camera will jump to when the objective is clicked in the ingame GUI
	/// The unit(s) must be within LoS
	/// </summary>
	[DataContract]
	public class AddUnitsToObjectiveAction : Action
	{
        string id;
		string group = String.Empty;

		public AddUnitsToObjectiveAction()
		{
		}

        [DataMember]
        public string ID
        {
            get { return id; }
            set
            {
                id = value;
                RaisePropertyChanged("ID");
            }
        }

        [DataMember]
        public string Group
        {
            get { return group; }
            set
            {
                group = value;
                RaisePropertyChanged("Group");
            }
        }

		public override LuaTable GetLuaTable(Mission mission)
		{
			var map = new Dictionary<object, object>
				{
					{"id", ID},
                    {"group", group},
				};
			return new LuaTable(map);
		}

		public override string GetDefaultName()
		{
			return "Add Units to Objective";
		}
	}
}