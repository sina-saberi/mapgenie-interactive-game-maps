import { toDataURL } from "./imageToDataURL";

const convertIconsToBase64Obj = async (slug: string, icons: (string | undefined)[]) => {
    const obj: Record<string, string> = {};
    const images = await convertIconsToBase64(slug, icons);
    images.forEach(image => {
        if (image.icon) {
            obj[image.icon] = image.url as string;
        }
    });

    return obj;
};

const convertIconsToBase64 = async (slug: string, iconss: (string | undefined)[]) => {
    const arr: { icon: string | undefined; url: string | ArrayBuffer | null }[] = [];

    const recursiveMap = async (icons: (string | undefined)[], index = 0) => {
        if (index >= icons.length) {
            return arr;
        }
        const icon = icons[index];
        if (icon) {
            const url = `${process.env.NEXT_PUBLIC_API_URL}/api/Asset/images/${slug}/${icon}.png`;
            const base64Data = await toDataURL(url); // Use pre-defined toDataURL function
            arr.push({
                icon,
                url: base64Data,
            });
        }
        return recursiveMap(icons, index + 1);
    };

    await recursiveMap(iconss);
    return arr;
};


export default convertIconsToBase64Obj