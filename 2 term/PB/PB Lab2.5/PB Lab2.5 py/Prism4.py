from Prism import Prism


class Prism4(Prism):
    def calculate_base_surface(self):
        return self.side_length ** 2

    def calculate_surface(self):
        return 2 * self.calculate_base_surface() + 4 * self.side_length * self.height

