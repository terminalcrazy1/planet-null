extends CharacterBody2D

@export var speed = 300
@onready var playersprite = $BaseSprite

func get_animation():
	if Input.is_action_pressed("Backward"):
		playersprite.play("walktocamera")
		#If walking backward (S), play walking backward animation
	elif Input.is_action_just_released("Backward"):
		playersprite.play("tocamerarest")
		#If walking towards camera (S) has stopped, play facing camera rest animation

	elif Input.is_action_pressed("Forward"):
		playersprite.play("walkfromcamera")
		#If walking away from camera (W), play walking forward animation
	elif Input.is_action_just_released("Forward"):
		playersprite.play("fromcamerarest")
		#If walking away from camera (W) has stopped, playing facing away from camera rest animation

	elif Input.is_action_pressed("Right"):
		playersprite.play("walkright")
		#If walking right, play walking right animation
	elif Input.is_action_just_released("Right"):
		playersprite.play("restright")
		#If not walking, but was walking right, play right shoulder to camera animation

	elif Input.is_action_pressed("Left"):
		playersprite.play("walkleft")
		#If walking left, play walking left animation
	elif Input.is_action_just_released("Left"):
		playersprite.play("restleft")
		#If not walking, but was walking left, play left shoulder to camera animation

func get_input():
	var input_direction = Input.get_vector("Left", "Right", "Forward", "Backward")
	velocity = input_direction * speed

func _physics_process(_delta):
	get_input()
	get_animation()
	move_and_slide()
