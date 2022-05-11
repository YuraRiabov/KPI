from abc import ABC, abstractmethod


class Prism(ABC):
    def __init__(self, height, side_length):
        self.height = height
        self.side_length = side_length

    @abstractmethod
    def calculate_surface(self):
        pass

    @abstractmethod
    def calculate_base_surface(self):
        pass

    def calculate_volume(self):
        return self.calculate_base_surface() * self.height
