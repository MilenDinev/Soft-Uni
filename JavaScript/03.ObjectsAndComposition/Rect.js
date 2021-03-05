function createRect(width, height){
    const rect = {width, height};
    rect.getArea = () => {
        return rect.width * rect.height;
    };
    return rect;
}

const myRect = createRect(15, 10);

console.log(myRect);

console.log(myRect.getArea());

const getArea = myRect.getArea;

console.log(getArea());