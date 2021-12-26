package main

import (
	"fmt"
	"os"
	"updater/inputs"
)

func main() {
	if len(os.Args) < 2 {
		fmt.Println("Not enough arguments")
		return
	}

	switch os.Args[1] {
	case "inputs":
		inputs.UpdateInputGroups()
	default:
		fmt.Println("Invalid argument")
	}
}
