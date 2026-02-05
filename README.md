# 🛗 Elevator System – Base “Area 51”

## 🧾 Overview
This project is a simulation of an elevator system operating inside the secret military base  
**“Area 51”**. Agents with different security clearance levels arrive at the base, use the
elevator to move between floors, and eventually leave.

The goal is to model elevator behavior, access control, and multithreaded execution in **C#**.

---

## 🏢 Base Structure
The base contains **four floors**:

- **G** – Ground floor  
- **S** – Secret floor (nuclear weapons)  
- **T1** – Secret floor (experimental weapons)  
- **T2** – Top-secret floor (alien remains 👽)

---

## 🕵️ Agent Security Levels
Each agent has one security clearance:

- **Confidential** → access to **G**
- **Secret** → access to **G, S**
- **Top-secret** → access to **G, S, T1, T2**

---

## 🛗 Elevator Rules
- One elevator serves all floors
- Each floor has a button to call the elevator
- Inside the elevator there are buttons for all floors
- When a button is pressed, all other buttons are disabled until arrival
- Elevator speed is **1 floor per second**
- Only **one agent** may use the elevator at a time
- The elevator door opens **only if** the agent has sufficient clearance
- If access is denied, the agent may choose another floor

---

## 🔄 Simulation Behavior
- Agents arrive at the base randomly
- Agents move between floors using the elevator
- Agents eventually leave the base
- Movement decisions are randomly generated

---

## 🧵 Multithreading
- Each agent runs in its **own thread**
- The elevator is handled by a **separate thread**
- Agents must wait after calling the elevator, just like in real life

---

## ✅ Implemented Features
- Elevator movement and timing
- Elevator call and floor buttons
- Security clearance checks before opening doors
- Threaded agents and elevator logic
- Basic agent movement simulation

---

## ℹ️ Notes
This is a **simplified simulation** created for learning purposes.
Not all real-world elevator edge cases are covered.
