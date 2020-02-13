from sense_hat import SenseHat

sense = SenseHat()


green = (0, 255, 0)
blue = (0, 0, 255)
red = (255, 0, 0)

while True:
    temp = sense.get_temperature()
    if temp < 18:
        sense.clear(blue)
    elif 18 < temp <= 22:
        sense.clear(green)
    elif temp > 22:
        sense.clear((red))
