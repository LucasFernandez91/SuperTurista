export class MenuItem {
    id: number;
    name: string;
    icon: string;
    route: string;
    subItems?: MenuItem[];
}

export class Menu {
    items: MenuItem[];
}
