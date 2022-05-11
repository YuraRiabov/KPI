import math

from Prism import Prism


class Prism3(Prism):
    def calculate_surface(self):
        return 2 * self.calculate_base_surface() + 3 * self.height * self.side_length

    def calculate_base_surface(self):
        return self.side_length ** 2 * math.sqrt(3) / 4

