package updategroups

import (
	"bufio"
	"fmt"
	"io/ioutil"
	"os"

	"gopkg.in/yaml.v2"
)

type UpdateGroupList struct {
	Groups []UpdateGroup `yaml:"groups"`
}

type UpdateGroup struct {
	Name        string `yaml:"name"`
	StartActive string `yaml:"startActive"`
}

const using string = "using System;\nusing System.Collections.Generic;\nusing UnityEngine;\n\n"
const namespace string = "namespace KXL.Core\n{\n"
const usingNamespace string = "using Enumerations;\nusing Interfaces;\n\n"
const enumHeader string = "public enum UpdateGroup\n{\n"
const classHeader string = "public static class UpdateGroupsManager\n{\n"
const dictionaryHeader = "private static Dictionary<UpdateGroup, bool> UpdateGroupsActive = new Dictionary<UpdateGroup, bool>() {\n"
const dictionaryNextHeader = "private static Dictionary<UpdateGroup, bool> UpdateGroupsActiveNext = new Dictionary<UpdateGroup, bool>() {\n"
const groupActiveFunc = "public static bool IsGroupActive(UpdateGroup group) {\nreturn UpdateGroupsActive[group];\n}\n"
const setGroupsStateFunc = "public static void SetUpdateGroupState(UpdateGroup group, bool state) {\nUpdateGroupsActiveNext[group] = state;\n}\n\n"
const switchGroup string = "switch (group) {\n"
const updateHeader string = "\npublic static void OnUpdate() {\n"
const updateUpdateGroupstate string = "\nvar keys = new List<UpdateGroup>(UpdateGroupsActive.Keys);\nforeach (var key in keys) {\nUpdateGroupsActive[key] = UpdateGroupsActiveNext[key];\n}\n"
const regUpdate string = "public static void RegisterUpdateConsumer(IUpdatable consumer, UpdateGroup group) {\n"
const unregUpdate string = "public static void UnregisterUpdateConsumer(IUpdatable consumer, UpdateGroup group) {\n"
const lateUpdateHeader string = "\npublic static void OnLateUpdate() {\n"
const regLateUpdate string = "public static void RegisterLateUpdateConsumer(ILateUpdatable consumer, UpdateGroup group) {\n"
const unregLateUpdate string = "public static void UnregisterLateUpdateConsumer(ILateUpdatable consumer, UpdateGroup group) {\n"

const groupsFileCs = "../KXL/Core/UpdateGroupsManager.cs"
const enumsFileCs = "../KXL/Core/Enumerations/UpdateGroup.cs"

func UpdateGroups() {
	groupsFile, err := ioutil.ReadFile("./data/updategroups.yaml")
	if err != nil {
		fmt.Println("Failed opening updategroups.yaml")
	}

	groups := &UpdateGroupList{}
	err = yaml.Unmarshal(groupsFile, groups)
	if err != nil {
		fmt.Println("Failed unmarshalling updategroups.yaml")
	}

	os.Truncate(enumsFileCs, 0)
	file, err := os.OpenFile(enumsFileCs, os.O_CREATE|os.O_WRONLY, 0644)
	if err != nil {
		fmt.Println("Failed opening UpdateGroup.cs")
	}
	datawriter := bufio.NewWriter(file)

	var result string
	result += "namespace KXL.Core.Enumerations\n{\n"
	result += enumHeader

	for _, g := range groups.Groups {
		result += fmt.Sprintf("%s,\n", g.Name)
	}
	result += "}\n}"

	_, _ = datawriter.WriteString(result)
	datawriter.Flush()
	file.Close()

	os.Truncate(groupsFileCs, 0)
	file, err = os.OpenFile(groupsFileCs, os.O_CREATE|os.O_WRONLY, 0644)
	if err != nil {
		fmt.Println("Failed opening UpdateGroupsManager.cs")
	}
	datawriter = bufio.NewWriter(file)

	result = ""
	result += using
	result += namespace
	result += usingNamespace

	result += classHeader
	result += dictionaryHeader

	for _, g := range groups.Groups {
		result += fmt.Sprintf("{UpdateGroup.%s, %s},\n", g.Name, g.StartActive)
	}

	result += "};\n\n"

	result += dictionaryNextHeader

	for _, g := range groups.Groups {
		result += fmt.Sprintf("{UpdateGroup.%s, %s},\n", g.Name, g.StartActive)
	}

	result += "};\n\n"

	result += groupActiveFunc
	result += setGroupsStateFunc

	for _, g := range groups.Groups {
		result += fmt.Sprintf("public static event Action On%sUpdate;\n", g.Name)
	}

	result += updateHeader

	for _, g := range groups.Groups {
		result += fmt.Sprintf("if (UpdateGroupsActive[UpdateGroup.%s]) {\nOn%sUpdate?.Invoke();\n}\n", g.Name, g.Name)
	}
	result += updateUpdateGroupstate
	result += "}\n\n"

	result += regUpdate
	result += switchGroup
	for _, g := range groups.Groups {
		result += fmt.Sprintf("case UpdateGroup.%s:\nOn%sUpdate += consumer.OnUpdate;\nbreak;\n", g.Name, g.Name)
	}
	result += "default:\nbreak;\n}\n}\n\n"

	result += unregUpdate
	result += switchGroup
	for _, g := range groups.Groups {
		result += fmt.Sprintf("case UpdateGroup.%s:\nOn%sUpdate -= consumer.OnUpdate;\nbreak;\n", g.Name, g.Name)
	}
	result += "default:\nbreak;\n}\n}\n\n"

	for _, g := range groups.Groups {
		result += fmt.Sprintf("public static event Action On%sLateUpdate;\n", g.Name)
	}

	result += lateUpdateHeader

	for _, g := range groups.Groups {
		result += fmt.Sprintf("if (UpdateGroupsActive[UpdateGroup.%s]) {\nOn%sLateUpdate?.Invoke();\n}\n", g.Name, g.Name)
	}
	result += "}\n\n"

	result += regLateUpdate
	result += switchGroup
	for _, g := range groups.Groups {
		result += fmt.Sprintf("case UpdateGroup.%s:\nOn%sLateUpdate += consumer.OnLateUpdate;\nbreak;\n", g.Name, g.Name)
	}
	result += "default:\nbreak;\n}\n}\n\n"

	result += unregLateUpdate
	result += switchGroup
	for _, g := range groups.Groups {
		result += fmt.Sprintf("case UpdateGroup.%s:\nOn%sLateUpdate -= consumer.OnLateUpdate;\nbreak;\n", g.Name, g.Name)
	}
	result += "default:\nbreak;\n}\n}\n}\n}"

	_, _ = datawriter.WriteString(result)
	datawriter.Flush()
	file.Close()
}
